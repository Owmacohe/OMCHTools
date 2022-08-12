using UnityEngine;

namespace OMCHTools
{
    public class Component : MonoBehaviour
    {
        #region Components

        public static void RemoveAllComponents<T>(GameObject obj) where T : Component
        {
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                Destroy(i);
            }
        }
        
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

        public static void SetAllRendererMaterials(GameObject obj, Material mat)
        {
            foreach (Renderer i in obj.GetComponentsInChildren<Renderer>())
            {
                i.material = mat;
            }
        }
        
        public static void SetAllRendererMaterials<T>(GameObject obj, Material mat) where T : Renderer
        {
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                i.material = mat;
            }
        }
        
        public static void SetAllRendererColors(GameObject obj, Color col)
        {
            foreach (Renderer i in obj.GetComponentsInChildren<Renderer>())
            {
                i.material.SetColor("Color", col);
            }
        }
        
        public static void SetAllRendererColors<T>(GameObject obj, Color col) where T : Renderer
        {
            foreach (T i in obj.GetComponentsInChildren<T>())
            {
                i.material.SetColor("Color", col);
            }
        }
        
        #endregion
        
        #region Meshes

        public static void SetMesh(GameObject obj, Vector3[] vertices, bool replaceCollider = true)
        {
            obj.GetComponent<MeshFilter>().mesh.SetVertices(vertices);

            if (replaceCollider)
            {
                Destroy(obj.GetComponent<MeshCollider>());
                obj.AddComponent<MeshCollider>();
            }
        }

        public static Vector3[] GetMesh(GameObject obj)
        {
            return obj.GetComponent<MeshFilter>().mesh.vertices;
        }
        
        #endregion
    }
}