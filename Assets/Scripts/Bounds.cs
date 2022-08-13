using UnityEngine;

namespace OMCHTools
{
    /// <summary>
    /// For getting Bounds properties of GameObjects
    /// </summary>
    public class Bounds
    {
        #region Center
        
        /// <summary>
        /// Gets the local center of the given GameObject's MeshFilter's bounds
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The local Vector3 position of the center of the bounds</returns>
        public static Vector3 GetLocalCenter(GameObject obj)
        {
            return Component.GetMesh(obj).bounds.center;
        }
        
        /// <summary>
        /// Gets the global center of the given GameObject's MeshFilter's bounds
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>The global Vector3 position of the center of the bounds</returns>
        public static Vector3 GetGlobalCenter(GameObject obj)
        {
            return obj.transform.TransformPoint(GetLocalCenter(obj));
        }
        
        #endregion
        
        #region Scale

        /// <summary>
        /// Gets the local scale of the given GameObject's MeshFilter's bounds
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>the local Vector3 scale of the bounds</returns>
        public static Vector3 GetLocalScale(GameObject obj)
        {
            return Component.GetMesh(obj).bounds.extents * 2;
        }

        /// <summary>
        /// Gets the global scale of the given GameObject's MeshFilter's bounds
        /// </summary>
        /// <param name="obj">The GameObject to be manipulated</param>
        /// <returns>the global Vector3 scale of the bounds</returns>
        public static Vector3 GetGlobalScale(GameObject obj)
        {
            return obj.transform.TransformVector(GetLocalScale(obj));
        }
        
        #endregion
    }
}