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
        /// <returns>The given array as global values (null if array is null)</returns>
        public static Vector3[] Vector3ToGlobal(Vector3[] arr, GameObject obj)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = obj.transform.TransformPoint(arr[i]);
                }

                return arr;   
            }
            
            Debug.Log("Array is null!");

            return null;
        }
        
        /// <summary>
        /// Converts a global Vector3 array to a local one, based on the given GameObject
        /// </summary>
        /// <param name="arr">The array of Vector3s to be converted</param>
        /// <param name="obj">The GameObject to be transformed against</param>
        /// <returns>The given array as local values</returns>
        public static Vector3[] Vector3ToLocal(Vector3[] arr, GameObject obj)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = obj.transform.InverseTransformPoint(arr[i]);
                }

                return arr;   
            }
            
            Debug.Log("Array is null!");

            return null;
        }

        #endregion

        #region Float
        
        /// <summary>
        /// Rounds each element in a float array to a certain number of decimal places
        /// </summary>
        /// <param name="arr">The array of floats to be converted</param>
        /// <param name="decim">The number of decimal places to round to</param>
        /// <returns>The given array rounded to decimal places</returns>
        public static float[] FloatRound(float[] arr, int decim)
        {
            if (arr != null)
            {
                int factor = (int)Mathf.Pow(10, decim);

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Mathf.RoundToInt(arr[i] * factor) / factor;
                }

                return arr;   
            }

            Debug.Log("Array is null!");

            return null;
        }
        
        #endregion
    }   
}