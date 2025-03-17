using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit() {
        StartCoroutine(Die());
    }

    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
