using UnityEngine;
namespace UnityNightPool.Example
{
    public class PlatformCreator : MonoBehaviour
    {
        [SerializeField]
        private Transform transformPlayer;
        [SerializeField]
        private Camera camera;
        private float cameraSizeY;
        private Vector3 default_OldPlatformPosition = new Vector3(0, -13.5f, 9);
        private Vector3 oldPlatformPosition;
        private Vector3 currentPlatformPosition;
        private float distansFromCenterToEdgeOldPlatform;
        private float leftRandomLimitX;
        private float rightRandomLimitX;
        private const float jumpLenght = 9;
        private const float jumpHeight = 4;
        private const float radiusCreativeZone = 9;

        private void Start()
        {
            cameraSizeY = camera.orthographicSize * 2;
            StartingSceneFilling();
        }
        void Update()
        {
            if (oldPlatformPosition.y - transformPlayer.transform.position.y < cameraSizeY) //ATTENTION! FIX IT!
            {
                CreatePlatform();
            }
        }

        private void CreatePlatform()
        {
            int idPlatform = Random.Range(1, 4);
            PoolObject platform = PoolManager.Get(idPlatform);
            float distansFromCenterToEdgeCurrentPlatform = platform.GetComponent<BoxCollider2D>().size.x * platform.transform.localScale.x / 2;
            float radiusCreativeZoneRelativeToCurrentPlatform = radiusCreativeZone + distansFromCenterToEdgeCurrentPlatform - 1;

            float yPossitionCurrentPlatformRelativeToZero = Random.Range(2, jumpHeight);
            float yPossitionCurrentPlatformRelativeToCharacter = yPossitionCurrentPlatformRelativeToZero + oldPlatformPosition.y;

            float currentJumpLenghtForThisY = MaxXforThisY(FindAforThisParabola(jumpLenght, 0, jumpHeight), yPossitionCurrentPlatformRelativeToZero, jumpHeight)
                + distansFromCenterToEdgeCurrentPlatform + distansFromCenterToEdgeOldPlatform;

            leftRandomLimitX = oldPlatformPosition.x - currentJumpLenghtForThisY < -radiusCreativeZoneRelativeToCurrentPlatform ?
                -radiusCreativeZoneRelativeToCurrentPlatform : oldPlatformPosition.x - currentJumpLenghtForThisY;
            rightRandomLimitX = oldPlatformPosition.x + currentJumpLenghtForThisY > radiusCreativeZoneRelativeToCurrentPlatform ?
                radiusCreativeZoneRelativeToCurrentPlatform : oldPlatformPosition.x + currentJumpLenghtForThisY;

            currentPlatformPosition = new Vector3(RandomWithConditions(leftRandomLimitX, rightRandomLimitX,
                oldPlatformPosition.x - currentJumpLenghtForThisY / 2, oldPlatformPosition.x + currentJumpLenghtForThisY / 2),
                yPossitionCurrentPlatformRelativeToCharacter, oldPlatformPosition.z);
            platform.transform.position = currentPlatformPosition;
            oldPlatformPosition = currentPlatformPosition;
            distansFromCenterToEdgeOldPlatform = distansFromCenterToEdgeCurrentPlatform;

            platform.GetComponent<Platform>().mainCamera = camera;
        }

        public void StartingSceneFilling()
        {
            oldPlatformPosition = default_OldPlatformPosition;
            while (oldPlatformPosition.y - transformPlayer.position.y < cameraSizeY) //ATTENTION! FIX IT!
            {
                CreatePlatform();
            }
        }

        private float RandomWithConditions(float min, float max, float conditionOne, float conditionTwo)
        {
            float randomNumber = Random.Range(leftRandomLimitX, rightRandomLimitX);

            if (randomNumber > conditionOne && randomNumber < conditionTwo)
            {
                return RandomWithConditions(min, max, conditionOne, conditionTwo);
            }

            return randomNumber;
        }

        //find the maximum value of X for the platform located at the specified Y, on which the character can jump
        private float FindAforThisParabola(float x, float y, float c)
        {
            float axSquared = y - c;
            float a = axSquared / (float)System.Math.Pow(x, 2f);
            return a;
        }
        private float MaxXforThisY(float a, float y, float c)
        {
            float axSquared = y - c;
            float xSquared = axSquared / a;
            float x = (float)System.Math.Sqrt(xSquared);
            return x;
        }
    }
}