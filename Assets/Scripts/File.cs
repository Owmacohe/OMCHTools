using UnityEngine;

namespace OMCHTools
{
    public class File
    {
        #region TXTToArray
        
        public static string[] TXTToStringArray(TextAsset asset)
        {
            string[] split = asset.text.Split('\n');

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = split[i].Trim();
            }

            return split;
        }
        
        public static string[] TXTToStringArray(string fileName)
        {
            return TXTToStringArray(Resources.Load<TextAsset>(fileName));
        }
        
        public static int[] TXTToIntArray(TextAsset asset)
        {
            string[] split = asset.text.Split('\n');
            int[] temp = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                temp[i] = int.Parse(split[i].Trim());
            }

            return temp;
        }
        
        public static int[] TXTToIntArray(string fileName)
        {
            return TXTToIntArray(Resources.Load<TextAsset>(fileName));
        }
        
        public static float[] TXTToFloatArray(TextAsset asset)
        {
            string[] split = asset.text.Split('\n');
            float[] temp = new float[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                temp[i] = float.Parse(split[i].Trim());
            }

            return temp;
        }
        
        public static float[] TXTToFloatArray(string fileName)
        {
            return TXTToFloatArray(Resources.Load<TextAsset>(fileName));
        }
        
        public static Vector3[] TXTToVector3Array(TextAsset asset)
        {
            string[] split = asset.text.Split('\n');
            Vector3[] temp = new Vector3[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                string[] splitSplit = split[i].Trim().Split(',');
                
                temp[i] = new Vector3(
                    float.Parse(splitSplit[0]),
                    float.Parse(splitSplit[1]),
                    float.Parse(splitSplit[2])
                );
            }

            return temp;
        }
        
        public static Vector3[] TXTToVector3Array(string fileName)
        {
            return TXTToVector3Array(Resources.Load<TextAsset>(fileName));
        }
        
        #endregion
        
        #region CSVToMatrix

        public static string[,] CSVToStringMatrix(TextAsset asset, char delim)
        {
            string[] split = asset.text.Split('\n');
            
            int ySize = split.Length;
            int xSize = split[0].Trim().Split(delim).Length;
            
            string[,] temp = new string[ySize, xSize];

            for (int i = 0; i < ySize; i++)
            {
                string[] splitSplit = split[i].Trim().Split(delim);
                
                for (int j = 0; j < xSize; j++)
                {
                    temp[i, j] = splitSplit[j];
                }
            }

            return temp;
        }

        public static string[,] CSVToStringMatrix(string fileName, char delim)
        {
            return CSVToStringMatrix(Resources.Load<TextAsset>(fileName), delim);
        }
        
        public static int[,] CSVToIntMatrix(TextAsset asset, char delim)
        {
            string[] split = asset.text.Split('\n');
            
            int ySize = split.Length;
            int xSize = split[0].Trim().Split(delim).Length;
            
            int[,] temp = new int[ySize, xSize];

            for (int i = 0; i < ySize; i++)
            {
                string[] splitSplit = split[i].Trim().Split(delim);
                
                for (int j = 0; j < xSize; j++)
                {
                    temp[i, j] = int.Parse(splitSplit[j]);
                }
            }

            return temp;
        }

        public static int[,] CSVToIntMatrix(string fileName, char delim)
        {
            return CSVToIntMatrix(Resources.Load<TextAsset>(fileName), delim);
        }
        
        public static float[,] CSVToFloatMatrix(TextAsset asset, char delim)
        {
            string[] split = asset.text.Split('\n');
            
            int ySize = split.Length;
            int xSize = split[0].Trim().Split(delim).Length;
            
            float[,] temp = new float[ySize, xSize];

            for (int i = 0; i < ySize; i++)
            {
                string[] splitSplit = split[i].Trim().Split(delim);
                
                for (int j = 0; j < xSize; j++)
                {
                    temp[i, j] = float.Parse(splitSplit[j]);
                }
            }

            return temp;
        }

        public static float[,] CSVToFloatMatrix(string fileName, char delim)
        {
            return CSVToFloatMatrix(Resources.Load<TextAsset>(fileName), delim);
        }
        
        public static Vector3[,] CSVToVector3Matrix(TextAsset asset, char delim)
        {
            if (!delim.Equals(','))
            {
                string[] split = asset.text.Split('\n');
            
                int ySize = split.Length;
                int xSize = split[0].Trim().Split(delim).Length;
            
                Vector3[,] temp = new Vector3[ySize, xSize];

                for (int i = 0; i < ySize; i++)
                {
                    string[] splitSplit = split[i].Trim().Split(delim);
                
                    for (int j = 0; j < xSize; j++)
                    {
                        string[] splitSplitSplit = splitSplit[j].Split(',');
                
                        temp[i, j] = new Vector3(
                            float.Parse(splitSplitSplit[0]),
                            float.Parse(splitSplitSplit[1]),
                            float.Parse(splitSplitSplit[2])
                        );
                    }
                }

                return temp;   
            }

            return null;
        }

        public static Vector3[,] CSVToVector3Matrix(string fileName, char delim)
        {
            return CSVToVector3Matrix(Resources.Load<TextAsset>(fileName), delim);
        }
        
        #endregion
    }
}