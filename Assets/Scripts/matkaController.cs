using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class matkaController : MonoBehaviour
{
    public List<GameObject> RegisteredObjects;
    public List<ElementTemplate> InPot;

    public Transform ElementStoragePoint;
    public TriggerInputDetector XRInput;

    private Dictionary<string, List<string>> Recipes;
    public VisualEffect poof;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        InPot = new List<ElementTemplate>();
        XRInput = FindObjectOfType<TriggerInputDetector>();

        if (File.Exists(Application.streamingAssetsPath + "/Recipes.json"))
        {
            Recipes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(Application.streamingAssetsPath +
                "/Recipes.json"));
            Debug.Log("Recipes Loaded");

            string recipeLog = "";
            foreach (var recipe in Recipes)
            {
                recipeLog += recipe.Key + "\n";
                foreach (var ing in recipe.Value)
                {
                    recipeLog += " >" + ing + "\n";
                }
            }
            
            Debug.Log(recipeLog);
        }
        else
        {
            Debug.Log("Recipes File does not Exist [Creating]");
            Recipes = new Dictionary<string, List<string>>();
            Recipes.Add("Wood",new List<string>{"Water", "Air", "Soil"});
            Recipes.Add("test", new List<string>{"dhruv","srm","madness"});
            
            File.WriteAllText(Application.streamingAssetsPath + "/Recipes.json" , JsonConvert.SerializeObject(Recipes,Formatting.Indented));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (XRInput.GetLeftPrimaryDown())
        {
            // Debug.Log("X Pressed");
            // CheckIngredients();
            SceneManager.LoadScene(1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ElementTemplate Element) && !InPot.Contains(Element))
        {
            InPot.Add(Element);
            Element.transform.position = ElementStoragePoint.position;
            Element.gameObject.SetActive(false);

            // if (InPot.Count > 1)
            // {
            //     StartCoroutine(ThrowIngredients());
            // }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ElementTemplate Element) && InPot.Contains(Element))
        {
            InPot.Remove(Element);
        }
    }


    public void CheckIngredients()
    {
        List<string> ingredients = new List<string>();
        foreach (var ing in InPot)         
        {
            ingredients.Add(ing.Elementname);
        }
        Debug.Log("Created List in Pot");

        foreach (var ing in ingredients)
        {
            Debug.Log(ing);
        }

        foreach (var recipe in Recipes)
        {
            Debug.Log("Checking => " + recipe.Key);
            // if (recipe.Value == ingredients)
            // {
            //     Debug.Log("generate "+ recipe.Key);
            // }

            bool check = false;
            if (recipe.Value.Count == ingredients.Count)
            {
                foreach (var ing in recipe.Value)
                {
                    if (!ingredients.Contains(ing))
                    {
                        check = true;
                    }
                    
                }
                
                if (!check)
                {
                    Debug.Log("generating => "+recipe.Key);


                    var foundObject = Instantiate(RegisteredObjects.Find(x => x.name == recipe.Key),ElementStoragePoint.position + new Vector3(0,0.82f,0),Quaternion.identity);
                    foundObject.GetComponent<RefillManager>().InitElement(true);
                    foundObject.GetComponent<Rigidbody>().AddForce(Vector3.up/2, ForceMode.Impulse);

                    foreach (var element in InPot)
                    {
                        Destroy(element);
                    }
                    InPot.Clear();
                    break;
                }

                Debug.Log("Does not fit any Recipe");
                ThrowIngredients();
                
            }
            else
            {
                Debug.Log("Does not match Ingredient Counts ");
                if (InPot.Count != 0)
                {
                    ThrowIngredients();
                }
            }

            
        }
        
    }

    public void ThrowIngredients()
    {
        foreach (var element in InPot)
        {
            Destroy(element);
        }
        InPot.Clear();
        poof.Play();

    }
}
