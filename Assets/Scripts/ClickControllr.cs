using UnityEngine;
using System;

#if !UNITY_EDITOR
using UWPLibrary;
using System.Threading.Tasks;
#endif

public class ClickControllr : MonoBehaviour
{
    public TextMesh text;
#if !UNITY_EDITOR
    FileAccessor file = new FileAccessor();
#endif
    private int counter = 0;
    // Start is called before the first frame update

#if !UNITY_EDITOR
    async void Start()
#else   
    void Start()
#endif
    {
        try
        {
#if !UNITY_EDITOR
            await file.CreateFile("sample.txt");
#endif
        }
        catch (Exception e)
        {
            text.text = e.Message;
        }
    }

#if !UNITY_EDITOR
    public async void Count()
#else
    public void Count()
#endif
    {
        try
        {
            counter++;
#if !UNITY_EDITOR
            await file.WriteToFile("sample.txt", counter.ToString());
#endif
        }
        catch (Exception e)
        {
            text.text = e.Message;
        }
    }

#if !UNITY_EDITOR
    public async void DisplayCount()
#else
    public void DisplayCount()
#endif
    {
        try
        {
            string data = string.Empty;
#if !UNITY_EDITOR
            data = await file.ReadFromFile("sample.txt");
#endif
            text.text = data;
        }
        catch (Exception e)
        {
            text.text = e.Message;
        }
    }
}
