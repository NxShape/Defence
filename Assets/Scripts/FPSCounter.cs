using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    #region FPS Counter
    public float updateInterval = 0.5F;
    private float lastInterval;
    private int frames = 0;
    private float fps;
    #endregion

    public Text FPSLabel;

    void Start()
    {
        //Сброс счетчика
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;

        StartCoroutine("Counter");
    }

    public void Update()
    {
        #region FPS Counter
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = frames / (timeNow - lastInterval);
            frames = 0;
            lastInterval = timeNow;
        }
        #endregion
    }

    IEnumerator Counter()
    {
        do
        {
            FPSLabel.text = fps.ToString("f2");
            yield return new WaitForSeconds(1.0f);
        } while (true);
    }
}
