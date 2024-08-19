using UnityEngine;

public class PlinkoGrid : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int rowCount = 12;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        int objectsPerRow = 3;

        float startX = 0f;
        float startY = 539f;
        float offsetX = 70f;
        float offsetY = 70f;

        for (int i = 0; i < rowCount; i++)
        {
            float currentRowStartX = startX - (objectsPerRow - 1) * offsetX / 2;

            for (int j = 0; j < objectsPerRow; j++)
            {
                Vector3 position = new Vector3(currentRowStartX + j * offsetX, startY - i * offsetY, 0);
                GameObject newObj = Instantiate(prefab, position, Quaternion.identity, transform);

                RectTransform rectTransform = newObj.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.anchoredPosition = position;
                }
            }

            objectsPerRow = Mathf.Min(objectsPerRow + 1, 16);
        }
    }

}
