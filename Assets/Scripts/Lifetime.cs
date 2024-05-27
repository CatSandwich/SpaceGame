using System.Collections;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [field: SerializeField]
    public float Time { get; private set; }
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Time);
        Destroy(gameObject);
    }
}
