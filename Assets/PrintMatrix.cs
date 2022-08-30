
using UnityEngine;
using UnityEngine.UI;
public class PrintMatrix : MonoBehaviour
{
    public Text screenText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(screenText != null)
		{
            screenText.text = ""+this.GetComponent<Camera>().projectionMatrix;

        }
        if(this.GetComponent<Camera>() != null)
		{
            Debug.Log(this.GetComponent<Camera>().projectionMatrix);
		}
        Debug.Log(transform.localToWorldMatrix);

    }
}
