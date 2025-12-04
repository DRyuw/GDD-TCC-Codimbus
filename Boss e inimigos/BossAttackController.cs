using UnityEngine;
using System.Collections;

public class BossAttackController : MonoBehaviour
{
    public DashCamarao dashCamarao;
    public BossMultiPunch multiPunch;
    public BossGatlingGun gatlingGun;

    void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(2f); 

        while (true)
        {
           
            if (dashCamarao != null)
            {
                dashCamarao.StartDash();
                yield return new WaitForSeconds(2f); 
            }

           
            if (multiPunch != null)
            {
                multiPunch.StartPunchSequence();
                yield return new WaitForSeconds(2f);
            }

            
            if (gatlingGun != null)
            {
                gatlingGun.StartGatlingAttack();
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
