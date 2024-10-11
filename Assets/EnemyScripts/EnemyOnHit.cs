using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyOnHit : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer spriteRenderer;

    public Coroutine hitCoroutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



      public IEnumerator FadeTo(Color targetColor, float duration)
    {
        Color initialColor = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            spriteRenderer.color = Color.Lerp(initialColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = targetColor;
    }


    public void HitResponse(){
        spriteRenderer.color = new Color(255, 0, 0);

        if(hitCoroutine != null){
            StopCoroutine(hitCoroutine);
        }

        hitCoroutine = StartCoroutine(FadeTo(new Color(255, 255, 255), 100f));
    }


}
