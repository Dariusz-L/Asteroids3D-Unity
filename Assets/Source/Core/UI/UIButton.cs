using Core.Objects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{
    public class UiButton : UnityObject
    {
        protected RectTransform rectTransform { get; private set; }
        protected EventTrigger trigger { get; private set; }

        protected virtual void OnPointerClick(PointerEventData data) {}
        protected virtual void OnPointerDown(PointerEventData data) {}
        protected virtual void OnPointerUp(PointerEventData data) { }
        protected virtual void OnPointerDrag(PointerEventData data) { }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;
                rectTransform = base.go.GetComponent<RectTransform>();

                trigger = base.go.AddComponent<EventTrigger>();

                EventTrigger.Entry entry;

                entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;
                entry.callback.AddListener((data) => { OnPointerClick((PointerEventData) data); });
                trigger.triggers.Add(entry);

                entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerDown;
                entry.callback.AddListener((data) => { OnPointerDown((PointerEventData) data); });
                trigger.triggers.Add(entry);

                entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerUp;
                entry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
                trigger.triggers.Add(entry);

                entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.Drag;
                entry.callback.AddListener((data) => { OnPointerDrag((PointerEventData)data); });
                trigger.triggers.Add(entry);
            }
        }
    }
}
