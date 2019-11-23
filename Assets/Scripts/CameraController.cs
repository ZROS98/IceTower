using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] private Transform startPlatform;
    [SerializeField] private PlayerMovement playerMovement;
    private float followSpeed = 10;
    private float cameraMoveSpeed = 0.05f;
    public bool startCameraMovement = false;
    public bool jumpIsDone = false;

    private void FixedUpdate()
    {
        if (!jumpIsDone)
        {
            if (playerMovement.startCamera)
            {
                startCameraMovement = true;
                jumpIsDone = true;
                startPlatform.transform.SetParent(null, true);
            }
        }
        

        if (startCameraMovement)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + cameraMoveSpeed);

            if (objectToFollow.transform.position.y > transform.position.y)
            {
                Vector3 positionToFollow =
                    new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, positionToFollow, followSpeed * Time.deltaTime);
            }
        }
    }

}