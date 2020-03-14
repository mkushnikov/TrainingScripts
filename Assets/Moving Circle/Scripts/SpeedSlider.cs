using UnityEngine;
using UnityEngine.UI;

namespace MovingCirle
{
    public class SpeedSlider : MonoBehaviour
    {
        [SerializeField] private GameObject _myCircle;
        [SerializeField] private Text _currentSpeedLabel;

        private void Awake() => ChangeSpeed();
        public void ChangeSpeed()
        {
            _currentSpeedLabel.text = GetComponent<Slider>().value.ToString();
            _myCircle.GetComponent<MyLittleCircle>().MoveSpeed = GetComponent<Slider>().value;
        }
    }
}
