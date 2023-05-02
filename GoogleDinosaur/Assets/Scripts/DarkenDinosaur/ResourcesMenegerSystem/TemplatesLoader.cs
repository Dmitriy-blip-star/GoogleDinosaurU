using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DarkenDinosaur.ResourcesManagementSystem
{
    public class TemplatesLoader : MonoBehaviour 
    {
        [Header("Settings")]
        [Tooltip("Loaded templates.")]
        [SerializeField] private List<GameObject> loadedTemplates; // Используемые(загруженные) шаблоны

        [Tooltip("Templates folder name in resources.")]
        [SerializeField] private string templatesFolderName; // Название папки в которой мы храним шаблоны

        [Tooltip("Template name prefix.")]
        [SerializeField] private string templatePrefix; // Префикс имени шаблона

        [Tooltip("Templates count in resources folder.")] // Количество шаблонов, которое будет храниться в папке ресурсов
        [SerializeField] private int templatesCount;

        /// <summary>
        /// Возвращает случайный шаблон из загруженного пула или папки ресурсов.
        /// </summary>
        /// <returns>Location template (GameObject)</returns>
        public GameObject GetRandomTemplate() // Метод возвращает шаблон, который мы будем спавнить на сцене
        {
            int templateId = Random.Range(1, this.templatesCount); 
            string templateName = this.templatePrefix + templateId; // Имя шаблона 
            if (this.loadedTemplates.Exists(t => t.name == templateName)) // Пытаемся найти нужный шаблон в списке загруженных шаблонов
            {
                Debug.Log("{<color=cyan><b>Template Loaded Log</b></color>} => [TemplatesLoader] - (<color=yellow>GetRandomTemplate</color>) -> Template " + templateName + " return from loaded templates.");
                GameObject template = this.loadedTemplates.Find(t => t.name == templateName); // в переменную template кладем результат поиска имени файла, который был сгенерирован ранее
                return template; // Возвращаем полученый из пула загруженных шаблонов шаблон
            }

            string templateResourcePath = Path.Combine(this.templatesFolderName, templateName); // Загружаем результат работы метода в строку
            GameObject loadedTemplate = Resources.Load<GameObject>(templateResourcePath); // создаем объект с помощью поиска по имени. в метод кладем имя папки и шаблона. он возвращает сам шаблон
            this.loadedTemplates.Add(loadedTemplate); // кладем результат работы метода(объект шаблон) в лист уже загруженных шаблонов(чтобы не приходилось выгружать их каждый раз заново)
            Debug.Log("{<color=cyan><b>Template Loaded Log</b></color>} => [TemplatesLoader] - (<color=yellow>GetRandomTemplate</color>) -> Template " + templateName + " loaded from resources.");
            return loadedTemplate; // возвращаем полученный шаблон. из папки(если он еще не был загружен или из внутреннего пула, если он встречается уже не первый раз)
        }
    }
}
