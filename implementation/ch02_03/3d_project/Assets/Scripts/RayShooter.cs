using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                // Debug.Log("Hit "+hit.point);
                // StartCoroutine(SphereIndicator(hit.point));
                GameObject hitObject = hit.transform.gameObject;
                // 这里用于检查组件 很关键
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) {
                    // Debug.Log("Target hit");
                    target.ReactToHit();
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                } 
            }
        }
    }

    // 这个函数会返回一个IEnumerator对象
    private IEnumerator SphereIndicator(Vector3 pos) {
        // sphere是球体
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        // yield return是暂停点，而不是传统意义的return
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
