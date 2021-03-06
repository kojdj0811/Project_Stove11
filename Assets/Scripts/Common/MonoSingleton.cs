using UnityEngine;
using System.Collections.Generic;
using System.Reflection;


public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T obj;

    [SerializeField]
    protected bool isDontDestroy = true;

    public static T Get()
    {
        return instance;
    }

    public static T instance
    {
        get
        {
			if (!obj)
            {
				obj = (T)FindObjectOfType(typeof(T));

                if (!obj)
                {

					obj = new GameObject(typeof(T).Name).AddComponent<T>();
                    obj.Initialize();
                }
                else
                    obj.Initialize();
            }

            return obj;
        }

        protected set { }
    }


    protected virtual void Awake()
    {
		if( obj != null )
		{
            Debug.LogError( "obj != null " + this.gameObject.name );
			return;
		}

		obj = this as T;
        instance.gameObject.name = typeof(T).Name;   

        if(isDontDestroy)
            DontDestroyOnLoad(instance);

        Debug.Log("Singleton : " + instance.gameObject.name);
    }

	public static void DestroySingleton()
	{
		if( obj == null )
			obj = (T)FindObjectOfType( typeof( T ) );

		if( obj != null )
			GameObject.DestroyImmediate( obj.gameObject );
		obj = null ;
	}

	public static bool isDestroyed()
    {
        return (obj == null);
    }

    void OnApplicationQuit()
    {
        obj = null;
        instance = null;
    }

    protected virtual void Initialize()
    {
    }

}