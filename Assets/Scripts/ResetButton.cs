using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameObjectInitialState
{
    public int id;
    public Vector3 position;
    public Quaternion rotation;
}
public class ResetButton : XRBaseInteractable
{
   

    private List<GameObjectInitialState> moveableGameObjects = new List<GameObjectInitialState>();
    protected override void Awake()
    {
        base.Awake();
        onHoverEnter.AddListener(OnButtonPress);

        // Store current position of all objects in game
        GameObject[] objects = GameObject.FindGameObjectsWithTag("MoveableGameObject");
        if(objects.Length > 0)
        {
            Debug.Log("si hay mas de 1 xd");
        }
        foreach (GameObject gameObject in objects)
        {
            GameObjectInitialState i = new GameObjectInitialState
            {
                id = gameObject.GetInstanceID(),
                position = gameObject.transform.position,
                rotation = gameObject.transform.rotation
            };
            
            moveableGameObjects.Add(i);
        }
    }
    private void OnButtonPress(XRBaseInteractor interactor)
    {
        GameObject[] currentGameObjects = GameObject.FindGameObjectsWithTag("MoveableGameObject");
        if (currentGameObjects.Length > 0)
        {
            Debug.Log("si hay mas de 12222 xd");
        }
        foreach (GameObject gameObject in currentGameObjects)
        {
            var storedGameObject = moveableGameObjects.Find(item => item.id == gameObject.GetInstanceID());

            if (storedGameObject != null)
            {
                if(storedGameObject.position != gameObject.transform.position && storedGameObject.rotation != gameObject.transform.rotation)
                {
                    gameObject.transform.position = storedGameObject.position;
                    gameObject.transform.rotation = storedGameObject.rotation;
                }

            }
        }
    }
}
