using UnityEngine;
using System.Collections;
 
public class TitulniPanacek : MonoBehaviour
{
    public float rychlost = 2f;
    public Vector2 start = new Vector2(26f, -28f);
    public Vector2 cil = new Vector2(16f, -8f);
    public float delayPoZmizeni = 2f;

    private Vector3 startPosition;
    private Vector3 startScale;

    void Start()
    {
        startPosition = new Vector3(start.x, start.y, transform.position.z);
        transform.position = startPosition;
        startScale = transform.localScale;
        StartCoroutine(PohybovaSmycka());
    }

    IEnumerator PohybovaSmycka()
    {
        while (true)
        {
            Vector3 cilPozice = new Vector3(cil.x, cil.y, startPosition.z);

            while (Vector3.Distance(transform.position, cilPozice) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    cilPozice,
                    rychlost * Time.deltaTime
                );
                yield return null;
            }

            transform.localScale = Vector3.zero;
            yield return new WaitForSeconds(delayPoZmizeni);

            transform.position = startPosition;
            transform.localScale = startScale;
        }
    }
}