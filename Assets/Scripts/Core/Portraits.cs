using UnityEngine;


public class Portraits : MonoBehaviour
{
    public Sprite[] portrait_pool;

    public Sprite Randomize()
    {
        return portrait_pool[Random.Range(0, portrait_pool.Length)];
    }
}
