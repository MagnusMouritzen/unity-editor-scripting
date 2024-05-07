using UnityEngine;

public class Example : MonoBehaviour
{
   [EnumData(typeof(TextStyle))] 
   public TextData[] textData;

   public void Write(TextStyle style)
   {
      Debug.Log("Using size " + textData[(int)style]);
   }

   private void Start()
   {
      Write(TextStyle.Big);
   }
}

public enum TextStyle
{
   Normal,
   Tiny,
   Small,
   Big,
   Huge,
   Gargantuan
}

[System.Serializable]
public class TextData
{
   public int size;
   public Color color;
}
