using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    public float viewDistance;
    public float viewAngle = 80;
    public float rotationZ;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (CanSeePlayer()) {
            //Debug.Log("Can see");
        }
    }

    bool CanSeePlayer() {
        //Debug.Log(Vector3.Angle(transform.right, (player.position - transform.position).normalized));
        if (Vector3.Distance(transform.position, player.position) < viewDistance) {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBeetweenGuardAndPlayer = Vector3.Angle(transform.up, dirToPlayer);

            if (angleBeetweenGuardAndPlayer < viewAngle) {
                Debug.Log("Can see");
                // if (!Physics2D.Linecast(transform.position, player.position, layerMask)) {
                //     return true;
                // }
            }
        }
        return false;
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}

        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
	}

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * viewDistance);
    }

}
