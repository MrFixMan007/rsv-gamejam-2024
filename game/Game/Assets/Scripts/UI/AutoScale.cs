using UnityEngine;

public class AutoScale : MonoBehaviour
{
    private Camera main_cam;
    void Start()
    {
        main_cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform.position = new Vector3(main_cam.transform.position.x, main_cam.transform.position.y, 20);
        Vector3 bottom_left = main_cam.ViewportToWorldPoint(Vector3.zero);
        Vector3 top_right = main_cam.ViewportToWorldPoint(new Vector3(main_cam.rect.width, main_cam.rect.height));
        Vector3 screen_size = top_right - bottom_left;
        float current_ratio = screen_size.x / screen_size.y;
        float optimal_ratio = transform.localScale.x / transform.localScale.y;

        if (current_ratio > optimal_ratio) 
        {
            float height = screen_size.y;
            transform.localScale = new Vector3(height * optimal_ratio, height);
        }
        else
        {
            float width = screen_size.x;
            transform.localScale = new Vector3(width, width / optimal_ratio);
        }
    }
}
