using UnityEngine;

namespace Yaygun.Utilities.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected virtual void Initialize() { }
        protected virtual void Destruction() { }

        protected virtual void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this as T;
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Destruction();
        }
        
    }
    public class SingletonPersistent<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected virtual void Initialize() { }
        protected virtual void Destruction() { }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Destruction();
        }
    }

    public class LazySingleton<T> where T : LazySingleton<T>, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }

        protected LazySingleton() 
        {
            Initialize();
        }

        protected virtual void Initialize() { }
    }
}
