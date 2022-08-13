using UnityEngine;

namespace OMCHTools
{
    /// <summary>
    /// For manipulating/removing/extracting Components from GameObjects
    /// </summary>
    public class Component : MonoBehaviour
    {
        #region Components

        /// <summary>
        /// Removes all Components of the given type from the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <typeparam name="T">The Component type to be removed</typeparam>
        public static void RemoveAllComponents<T>(GameObject obj) where T : Component
        {
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                Destroy(i);
            }
        }
        
        /// <summary>
        /// Add a Component of the given type to the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <typeparam name="T">The Component type to be added</typeparam>
        /// <returns>The newly added Component on the given GameObject</returns>
        public static T AddAllComponents<T>(GameObject obj) where T : Component
        {
            T temp = obj.AddComponent<T>();
            
            Transform objTransform = obj.transform;

            for (int i = 0; i < objTransform.childCount; i++)
            {
                AddAllComponents<T>(objTransform.gameObject);
            }

            return temp;
        }
        
        #endregion
        
        #region Renderers

        /// <summary>
        /// Sets the Material of each type of Renderer on the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="mat">The Material to be applied</param>
        public static void SetAllRendererMaterials(GameObject obj, Material mat)
        {
            foreach (Renderer i in obj.GetComponentsInChildren<Renderer>())
            {
                i.material = mat;
            }
        }
        
        /// <summary>
        /// Sets the Material of the given type of Renderer on the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="mat">The Material to be applied</param>
        /// <typeparam name="T">The Renderer type to be set</typeparam>
        public static void SetAllRendererMaterials<T>(GameObject obj, Material mat) where T : Renderer
        {
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                i.material = mat;
            }
        }
        
        /// <summary>
        /// The most common Material main color property
        /// </summary>
        static readonly int Color = Shader.PropertyToID("_Color");
        
        /// <summary>
        /// Sets the Color of the Material of each type of Renderer on the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="col">Color of the Material to be applied</param>
        public static void SetAllRendererColors(GameObject obj, Color col)
        {
            foreach (Renderer i in obj.GetComponentsInChildren<Renderer>())
            {
                i.material.SetColor(Color, col);
            }
        }
        
        /// <summary>
        /// Sets the Color of the Material of the given type of Renderer on the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="col">The Color of the Material to be applied</param>
        /// <typeparam name="T">The Renderer type to be set</typeparam>
        public static void SetAllRendererColors<T>(GameObject obj, Color col) where T : Renderer
        {
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                i.material.SetColor(Color, col);
            }
        }
        
        #endregion
        
        #region Meshes

        /// <summary>
        /// Gets the Mesh property of a given GameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The Mesh used on this gameObject</returns>
        public static Mesh GetMesh(GameObject obj)
        {
            return obj.GetComponent<MeshFilter>().mesh;
        }

        /// <summary>
        /// Sets the local mesh vertices of a given GameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="vertices">The Vector3 array of local mesh points to be applied</param>
        /// <param name="replaceCollider">Whether or not to re-calculate the MeshCollider as well (true by default)</param>
        public static void SetLocalMeshArray(GameObject obj, Vector3[] vertices, bool replaceCollider = true)
        {
            GetMesh(obj).SetVertices(vertices);

            if (replaceCollider)
            {
                Destroy(obj.GetComponent<MeshCollider>());
                obj.AddComponent<MeshCollider>();
            }
        }
        
        /// <summary>
        /// Sets the global mesh vertices of a given GameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="vertices">The Vector3 array of global mesh points to be applied</param>
        /// <param name="replaceCollider">Whether or not to re-calculate the MeshCollider as well (true by default)</param>
        public static void SetGlobalMeshArray(GameObject obj, Vector3[] vertices, bool replaceCollider = true)
        {
            SetLocalMeshArray(obj, Array.Vector3ArrayGlobalToLocal(vertices, obj), replaceCollider);
        }

        /// <summary>
        /// Gets the local mesh vertices of a given gameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The Vector3 array of local mesh points</returns>
        public static Vector3[] GetLocalMeshArray(GameObject obj)
        {
            return GetMesh(obj).vertices;
        }
        
        /// <summary>
        /// Gets the global mesh vertices of a given gameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The Vector3 array of global mesh points</returns>
        public static Vector3[] GetGlobalMeshArray(GameObject obj)
        {
            return Array.Vector3ArrayLocalToGlobal(GetLocalMeshArray(obj), obj);
        }
        
        #endregion
    }
}