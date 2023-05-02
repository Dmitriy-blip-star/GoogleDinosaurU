using System;
using System.Collections.Generic;
using System.Linq;
using DarkenDinosaur.ResourcesManagementSystem;
using UnityEngine;

namespace DarkenDinosaur.Map
{
    [RequireComponent(typeof(TemplatesLoader))]
    public class MapSpawner : MonoBehaviour // Отвечает за спавн частей карты
    {
        [Header("Components")]
        [SerializeField] private TemplatesLoader templatesLoader; // определяем поле для ранее написанного компонента,  который генерирует и загружает случайные части карты из папки

        [Header("Settings")]
        [Tooltip("Map parent transform.")]
        [SerializeField] private Transform templatesParentTransform; // трансформ того объекта внутрь которого должны будут складываться новые шаблоны

        [Tooltip("Templates count on scene in one moment.")]
        [SerializeField] private int templatesPoolSize; // Количество частей карты, которые одновременно могут находиться на сцене

        [Tooltip("Template size.")]
        [SerializeField] private Vector3 templateSize; // размер одного шаблона

        [Tooltip("Templates on scene.")]
        [SerializeField] private List<GameObject> spawnedTemplates; // лист содержит ссылки на те шаблоны, которые уже находятся на сцене

        private void Awake()
        {
            if (this.templatesLoader == null) this.templatesLoader = GetComponent<TemplatesLoader>(); // если поле не определенно заранее, определяем его(внутри unity)
        }

        private void Update()
        {
            if (this.spawnedTemplates.Count < this.templatesPoolSize) // если количество заспавненных шаблонов меньше необходимого(указываем самостоятельно через unity) вызываем метод спавна
            {
                SpawnTemplate();
            }
        }

        /// <summary>
        /// Spawn new template on scene.
        /// </summary>
        private void SpawnTemplate()
        {
            GameObject template = this.templatesLoader.GetRandomTemplate(); // получаем случайный шаблон с помощью ранее написанного компонента
            GameObject spawnedTemplate = Instantiate(template, this.templatesParentTransform); // создаем новый шаблон. передаем объект, полученный при отработке метода выше и передаем templatesParentTransform


            //рассчитываем позицию для той части карты, которую мы заспавнили
            GameObject lastSpawnedTemplate = this.spawnedTemplates.Last(); // берем последний заспавненный шаблон
            Vector3 lastSpawnedTemplatePosition = lastSpawnedTemplate.transform.localPosition; // берем его позицию 
            Vector3 templatePosition = lastSpawnedTemplatePosition + this.templateSize; // и прибавляем к его позиции, размер нашего шаблона

            spawnedTemplate.transform.localPosition = templatePosition; // присваиваем локальную позицию к новому шаблону
            this.spawnedTemplates.Add(spawnedTemplate); // и кладем его в список заспавненных шаблонов
        }

        /// <summary>
        /// Destroy template from scene.
        /// </summary>
        /// <param name="template">Template to destroying.</param>
        public void DeleteTemplate(GameObject template) // позже напишем компонент. при столкновении с другим gameobjectom будет уничтожаться объект, на котором будет висеть определенный компонент
                                                        // из него мы сможем обратиться сюда и передать тот gameoblect, который мы хоти удалить
        {
            this.spawnedTemplates.Remove(template); // удаляем объект сначала из списка находящихся на карте шаблонов
            Destroy(template); // а потом и со сцены
        }
    }
}