using UnityEngine;

namespace OMCHTools
{
    /// <summary>
    /// For manipulating arrays
    /// </summary>
    public class Array
    {
        #region Vector3

        /// <summary>
        /// Converts a local Vector3 array to a global one, based on the given GameObject
        /// </summary>
        /// <param name="arr">The array of Vector3s to be converted</param>
        /// <param name="obj">The GameObject to be transformed against</param>
        /// <returns>The given array as global values</returns>
        public static Vector3[] Vector3ArrayLocalToGlobal(Vector3[] arr, GameObject obj)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = obj.transform.TransformPoint(arr[i]);
            }

            return arr;
        }
        
        /// <summary>
        /// Converts a global Vector3 array to a local one, based on the given GameObject
        /// </summary>
        /// <param name="arr">The array of Vector3s to be converted</param>
        /// <param name="obj">The GameObject to be transformed against</param>
        /// <returns>The given array as local values</returns>
        public static Vector3[] Vector3ArrayGlobalToLocal(Vector3[] arr, GameObject obj)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = obj.transform.InverseTransformPoint(arr[i]);
            }

            return arr;
        }

        #endregion
    }   
}