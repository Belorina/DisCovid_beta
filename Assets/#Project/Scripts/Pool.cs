using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawn takVariant ( tag = Not_Masked) on beat 


public class Pool : MonoBehaviour
{
    public List<TikTakBehaviour> tiktaks = new List<TikTakBehaviour>();
    public GameObject tiktakPrefab;
    //public GameObject tiktakPrefabVariant;

    public TikTakBehaviour Create(Vector3 position, Quaternion rotation)
    {
        TikTakBehaviour tiktak = null;

         if (tiktaks.Count > 0)
        {
            tiktak = tiktaks[0];
            tiktaks.RemoveAt(0);
            tiktak.transform.rotation = rotation;
            tiktak.transform.position = position;
            tiktak.gameObject.SetActive(true);
        }
        else
        {
            GameObject tiktakGo = Instantiate(tiktakPrefab, position, rotation);
            tiktak = tiktakGo.GetComponent<TikTakBehaviour>();
            
            tiktak.pool = this;
        }

        return tiktak;
    }

    public void Kill(TikTakBehaviour tiktak)
    {
        tiktak.gameObject.SetActive(false);
        tiktaks.Add(tiktak);
    }


}
