using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Enemy
{
    private bool inRandom = false;
    private int i = 0;
    // Update is called once per frame
    void Update()
    {
        mirrorPersonality();
    }

    private void mirrorPersonality()
    {
        if (!roaming && !frightenedState && !inRandom) StartCoroutine("myRandomRoam", 10);
        if (navMeshAgent.velocity.normalized.magnitude > 0.1f)
        {
            anim.SetFloat("Speed", navMeshAgent.velocity.normalized.magnitude);
        }
    }

    private IEnumerator myRandomRoam(float time)
    {
        inRandom = true;
        float timer = 0f;
        while (timer < time && i < randomPositions.Length)
        {
            timer += Time.deltaTime;
            navMeshAgent.SetDestination(randomPositions[i].transform.position);
            if ((transform.position - randomPositions[i].transform.position).magnitude < 1f)
            {
                i += 1;
                if (i == 10) i = 0;
            }
            yield return null;
        }
        inRandom = false;
        yield return null;
    }
}
