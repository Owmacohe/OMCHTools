using System.Collections.Generic;
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
        /// Adds a Component of the given type to the given GameObject and all its children
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

        /// <summary>
        /// Gets all Components of the given type from the given GameObject and all its children
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <typeparam name="T">The Component type to be gotten</typeparam>
        /// <returns>An array of all the gotten Components</returns>
        public static T[] GetAllComponents<T>(GameObject obj) where T : Component
        {
            List<T> temp = new List<T>();
            
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                temp.Add(i);
            }

            return temp.ToArray();
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
                if (i.material.HasColor(Color))
                {
                    i.material.SetColor(Color, col);   
                }
                else
                {
                    Debug.Log("Material " + i.material.name + " doesn't have a main color property!");
                }
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
                if (i.material.HasColor(Color))
                {
                    i.material.SetColor(Color, col);   
                }
                else
                {
                    Debug.Log("Material " + i.material.name + " doesn't have a main color property!");
                }
            }
        }
        
        #endregion
        
        #region Meshes

        /// <summary>
        /// Gets the Mesh property of a given GameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The Mesh used on this GameObject (null if it doesn't have a mesh)</returns>
        internal static Mesh GetMesh(GameObject obj)
        {
            MeshFilter temp = obj.GetComponent<MeshFilter>();

            if (temp != null)
            {
                return obj.GetComponent<MeshFilter>().mesh;   
            }
            
            Debug.Log("GameObject doesn't have a mesh!");

            return null;
        }

        /// <summary>
        /// Sets the local mesh vertices of a given GameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="vertices">The Vector3 array of local mesh points to be applied</param>
        /// <param name="replaceCollider">Whether or not to re-calculate the MeshCollider as well (true by default)</param>
        public static void SetLocalMeshVertices(GameObject obj, Vector3[] vertices, bool replaceCollider = true)
        {
            Mesh temp = GetMesh(obj);

            if (temp != null)
            {
                obj.GetComponent<MeshFilter>().mesh.SetVertices(vertices);

                if (replaceCollider)
                {
                    Destroy(obj.GetComponent<MeshCollider>());
                    obj.AddComponent<MeshCollider>();
                }   
            }
        }
        
        /// <summary>
        /// Sets the global mesh vertices of a given GameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <param name="vertices">The Vector3 array of global mesh points to be applied</param>
        /// <param name="replaceCollider">Whether or not to re-calculate the MeshCollider as well (true by default)</param>
        public static void SetGlobalMeshVertices(GameObject obj, Vector3[] vertices, bool replaceCollider = true)
        {
            SetLocalMeshVertices(obj, Array.Vector3ToLocal(vertices, obj), replaceCollider);
        }

        /// <summary>
        /// Gets the local mesh vertices of a given gameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The Vector3 array of local mesh points (null if it doesn't have a mesh)</returns>
        public static Vector3[] GetLocalMeshVertices(GameObject obj)
        {
            Mesh temp = GetMesh(obj);
            
            if (temp != null)
            {
                return GetMesh(obj).vertices;   
            }

            return null;
        }
        
        /// <summary>
        /// Gets the global mesh vertices of a given gameObject's MeshFilter
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The Vector3 array of global mesh points (null if it doesn't have a mesh)</returns>
        public static Vector3[] GetGlobalMeshVertices(GameObject obj)
        {
            Vector3[] temp = GetLocalMeshVertices(obj);

            if (temp != null)
            {
                return Array.Vector3ToGlobal(temp, obj);   
            }

            return null;
        }
        
        #endregion
    }
}