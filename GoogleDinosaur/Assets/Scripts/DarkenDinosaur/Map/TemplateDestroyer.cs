using UnityEngine;

namespace DarkenDinosaur.Map
{
    [RequireComponent(typeof(Rigidbody2D))] // при подключении скрипта, подключатся указанные компоненты
    [RequireComponent(typeof(BoxCollider2D))]
    public class TemplateDestroyer : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MapSpawner spawner;

        private void Awake()
        {
            if (this.spawner == null) this.spawner = FindObjectOfType<MapSpawner>(); // если поле не определенно заранее, определяем его(внутри unity)
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.gameObject.tag)
            {
                case "LocationTemplate":
                    this.spawner.DeleteTemplate(other.transform.parent.gameObject); // если тег столкнувшегося объекта == LocationTemplate, мы передаем родителя того объекта который столкнулся
                                                                                    // т.к сталкиваться будет только один объект, а шаблон состоит из нескольких и гаходятся они все внутри родителя
                    break;
            }
        }
    }
}