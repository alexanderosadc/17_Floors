using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    private static Scene scene;

    public static Color sceneTransitionColor = Color.black;
    public static float sceneTransitionDamp = 2.0f;

    public static Scene GetScene()
    {
        if (scene == null)
        {
            scene = GameObject.Find("Scene").GetComponent<Scene>();
        }

        return scene;
    }
    
    public static void GoTo(string scene)
    {
        GoToScene(scene, sceneTransitionColor, sceneTransitionDamp);
    }

    public static void GoToScene (string scene, Color col, float damp)
    {
        if (! Application.CanStreamedLevelBeLoaded(scene))
        {
            throw new Exception("Undefined scene: " + scene);
        }

        GameObject init = new GameObject();
        init.name = "Fader";
        init.AddComponent<Fader>();
        Fader scr = init.GetComponent<Fader>();
        scr.fadeDamp = damp;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        scr.start = true;
    }

    public static int GetCurrentFloor()
    {
        return GetScene().GetFloor();
    }
}