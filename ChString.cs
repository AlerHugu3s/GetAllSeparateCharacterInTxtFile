using System.Collections;

namespace GetAllSeparateCharacterInTxtFile;

public class ChString : IEnumerable
{
    private string str = "";
    
    public ChString(){}

    public ChString(string str)
    {
        this.str = str;
    }

    public IEnumerator GetEnumerator()
    {
        return new ChStringEnum(str);
    }
}

public class ChStringEnum : IEnumerator
{
    private string list;
    private int position = -1;

    public ChStringEnum(string list)
    {
        this.list = list;
    }


    public bool MoveNext()
    {
        if (0 <= position && position <= list.Length)
        {
            int codePoint = Char.ConvertToUtf32(list, position);
            if (codePoint > 0xffff)
                position += 2;
            else
                position++;
        }
        else 
            position++;

        return position < list.Length;
    }

    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get
        {
            return Char.ConvertToUtf32(list, position);
        }
    }
}