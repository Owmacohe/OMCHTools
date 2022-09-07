using UnityEngine;

namespace OMCHTools
{
    /// <summary>
    /// For reading array data from various types of TextAssets
    /// </summary>
    public class File
    {
        #region TXTToArray
        
        /// <summary>
        /// Converts a given TextAsset into a string array of lines
        /// </summary>
        /// <param name="asset">The .txt file to be split</param>
        /// <returns>A string array of the lines in the file (null if empty)</returns>
        public static string[] TXTToStringArray(TextAsset asset)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');

                for (int i = 0; i < split.Length; i++)
                {
                    split[i] = split[i].Trim();
                }

                return split;
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }
        
        /// <summary>
        /// Converts a TextAsset in the Resources folder into a string array of lines
        /// </summary>
        /// <param name="fileName">The local name of the .txt file to be split in Resources</param>
        /// <returns>A string array of the lines in the file (null if empty)</returns>
        public static string[] TXTToStringArray(string fileName)
        {
            return TXTToStringArray(Resources.Load<TextAsset>(fileName));
        }
        
        /// <summary>
        /// Converts a given TextAsset into an int array of lines
        /// </summary>
        /// <param name="asset">The .txt file to be split</param>
        /// <returns>An int array of the lines in the file (null if empty)</returns>
        public static int[] TXTToIntArray(TextAsset asset)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
                int[] temp = new int[split.Length];

                for (int i = 0; i < split.Length; i++)
                {
                    temp[i] = int.Parse(split[i].Trim());
                }

                return temp;   
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }
        
        /// <summary>
        /// Converts a TextAsset in the Resources folder into an int array of lines
        /// </summary>
        /// <param name="fileName">The local name of the .txt file to be split in Resources</param>
        /// <returns>An int array of the lines in the file (null if empty)</returns>
        public static int[] TXTToIntArray(string fileName)
        {
            return TXTToIntArray(Resources.Load<TextAsset>(fileName));
        }
        
        /// <summary>
        /// Converts a given TextAsset into a float array of lines
        /// </summary>
        /// <param name="asset">The .txt file to be split</param>
        /// <returns>A float array of the lines in the file (null if empty)</returns>
        public static float[] TXTToFloatArray(TextAsset asset)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
                float[] temp = new float[split.Length];

                for (int i = 0; i < split.Length; i++)
                {
                    temp[i] = float.Parse(split[i].Trim());
                }

                return temp;
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }
        
        /// <summary>
        /// Converts a TextAsset in the Resources folder into a float array of lines
        /// </summary>
        /// <param name="fileName">The local name of the .txt file to be split in Resources</param>
        /// <returns>A float array of the lines in the file (null if empty)</returns>
        public static float[] TXTToFloatArray(string fileName)
        {
            return TXTToFloatArray(Resources.Load<TextAsset>(fileName));
        }
        
        /// <summary>
        /// Converts a given TextAsset into a Vector3 array of lines
        /// </summary>
        /// <param name="asset">The .txt file to be split</param>
        /// <param name="delim">The deliminator between x, y, and z values for each line (',' by default)</param>
        /// <returns>A Vector3 array of the lines in the file (null if empty)</returns>
        public static Vector3[] TXTToVector3Array(TextAsset asset, char delim = ',')
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
                Vector3[] temp = new Vector3[split.Length];

                for (int i = 0; i < split.Length; i++)
                {
                    string[] splitSplit = split[i].Trim().Split(delim);
                
                    temp[i] = new Vector3(
                        float.Parse(splitSplit[0]),
                        float.Parse(splitSplit[1]),
                        float.Parse(splitSplit[2])
                    );
                }

                return temp;   
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }
        
        /// <summary>
        /// Converts a TextAsset in the Resources folder into a Vector3 array of lines
        /// </summary>
        /// <param name="fileName">The local name of the .txt file to be split in Resources</param>
        /// <param name="delim">The deliminator between x, y, and z values for each line (',' by default)</param>
        /// <returns>A Vector3 array of the lines in the file (null if empty)</returns>
        public static Vector3[] TXTToVector3Array(string fileName, char delim)
        {
            return TXTToVector3Array(Resources.Load<TextAsset>(fileName), delim);
        }
        
        #endregion
        
        #region CSVToMatrix
        
        /// <summary>
        /// Converts a given TextAsset into a 2D string matrix of cells
        /// </summary>
        /// <param name="asset">The .csv file to be split</param>
        /// <returns>A 2D string matrix of the cells in the file (null if empty)</returns>
        public static string[,] CSVToStringMatrix(TextAsset asset)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
            
                int ySize = split.Length;
                int xSize = split[0].Trim().Split(',').Length;
            
                string[,] temp = new string[ySize, xSize];

                for (int i = 0; i < ySize; i++)
                {
                    string[] splitSplit = split[i].Trim().Split(',');
                
                    for (int j = 0; j < xSize; j++)
                    {
                        temp[i, j] = splitSplit[j];
                    }
                }

                return temp;   
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }

        /// <summary>
        /// Converts a TextAsset in the Resources folder into a 2D string matrix of cells
        /// </summary>
        /// <param name="fileName">The local name of the .csv file to be split in Resources</param>
        /// <returns>A 2D string matrix of the cells in the file (null if empty)</returns>
        public static string[,] CSVToStringMatrix(string fileName)
        {
            return CSVToStringMatrix(Resources.Load<TextAsset>(fileName));
        }
        
        /// <summary>
        /// Converts a given TextAsset into a 2D int matrix of cells
        /// </summary>
        /// <param name="asset">The .csv file to be split</param>
        /// <returns>A 2D int matrix of the cells in the file (null if empty)</returns>
        public static int[,] CSVToIntMatrix(TextAsset asset)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
            
                int ySize = split.Length;
                int xSize = split[0].Trim().Split(',').Length;
            
                int[,] temp = new int[ySize, xSize];

                for (int i = 0; i < ySize; i++)
                {
                    string[] splitSplit = split[i].Trim().Split(',');
                
                    for (int j = 0; j < xSize; j++)
                    {
                        temp[i, j] = int.Parse(splitSplit[j]);
                    }
                }

                return temp;   
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }

        /// <summary>
        /// Converts a TextAsset in the Resources folder into a 2D int matrix of cells
        /// </summary>
        /// <param name="fileName">The local name of the .csv file to be split in Resources</param>
        /// <returns>A 2D int matrix of the cells in the file (null if empty)</returns>
        public static int[,] CSVToIntMatrix(string fileName)
        {
            return CSVToIntMatrix(Resources.Load<TextAsset>(fileName));
        }
        
        /// <summary>
        /// Converts a given TextAsset into a 2D float matrix of cells
        /// </summary>
        /// <param name="asset">The .csv file to be split</param>
        /// <returns>A 2D float matrix of the cells in the file (null if empty)</returns>
        public static float[,] CSVToFloatMatrix(TextAsset asset)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
            
                int ySize = split.Length;
                int xSize = split[0].Trim().Split(',').Length;
            
                float[,] temp = new float[ySize, xSize];

                for (int i = 0; i < ySize; i++)
                {
                    string[] splitSplit = split[i].Trim().Split(',');
                
                    for (int j = 0; j < xSize; j++)
                    {
                        temp[i, j] = float.Parse(splitSplit[j]);
                    }
                }

                return temp;   
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }

        /// <summary>
        /// Converts a TextAsset in the Resources folder into a 2D float matrix of cells
        /// </summary>
        /// <param name="fileName">The local name of the .csv file to be split in Resources</param>
        /// <returns>A 2D float matrix of the cells in the file (null if empty)</returns>
        public static float[,] CSVToFloatMatrix(string fileName)
        {
            return CSVToFloatMatrix(Resources.Load<TextAsset>(fileName));
        }

        /// <summary>
        /// Converts a given TextAsset into a 2D Vector3 matrix of cells
        /// </summary>
        /// <param name="asset">The .csv file to be split</param>
        /// <param name="delim">The deliminator between x, y, and z values for each cell (can't be ',')</param>
        /// <returns>A 2D Vector3 matrix of the cells in the file (null if empty)</returns>
        public static Vector3[,] CSVToVector3Matrix(TextAsset asset, char delim)
        {
            if (!asset.text.Trim().Equals(""))
            {
                string[] split = asset.text.Split('\n');
            
                int ySize = split.Length;
                int xSize = split[0].Trim().Split(',').Length;
            
                Vector3[,] temp = new Vector3[ySize, xSize];

                for (int i = 0; i < ySize; i++)
                {
                    string[] splitSplit = split[i].Trim().Split(',');
                
                    for (int j = 0; j < xSize; j++)
                    {
                        string[] splitSplitSplit = splitSplit[j].Split(delim);
                
                        temp[i, j] = new Vector3(
                            float.Parse(splitSplitSplit[0]),
                            float.Parse(splitSplitSplit[1]),
                            float.Parse(splitSplitSplit[2])
                        );
                    }
                }

                return temp;   
            }
            
            Debug.Log("File " + asset.name + " is empty!");

            return null;
        }

        /// <summary>
        /// Converts a TextAsset in the Resources folder into a 2D Vector3 matrix of cells
        /// </summary>
        /// <param name="fileName">The local name of the .csv file to be split in Resources</param>
        /// <param name="delim">The deliminator between x, y, and z values for each cell (can't be ',')</param>
        /// <returns>A 2D Vector3 matrix of the cells in the file (null if empty)</returns>
        public static Vector3[,] CSVToVector3Matrix(string fileName, char delim)
        {
            return CSVToVector3Matrix(Resources.Load<TextAsset>(fileName), delim);
        }
        
        #endregion
    }
}