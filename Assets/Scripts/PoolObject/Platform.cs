using System.Collections;
using UnityEngine;
using UnityNightPool;

namespace UnityNightPool.Example
{
    public class Platform : MonoBehaviour
    {
        public Camera mainCamera;

        void Update()
        {
            if (gameObject.transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
            {
                StartCoroutine(Destroy());
            }
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(3f);
            GetComponent<PoolObject>().Return();
        }
    }
}