using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Linq;
public class Card : MonoBehaviour
{

    public CardPrefab CardPrefab;
    public TMP_Text CountText;
    public Image ObstacleImage;
    public Color ClickColorForText;
    public List<GameObject> _sides;



    private int _startCount, _currentCount;
    private GameObject _obstacleType;
    private Sprite _buttonImage;
    private ButtonEffect _buttonEffect;
    private Vector3 _textStartSize;
    private bool _canClick;

    void Start()
    {
        _canClick = true;

        _startCount = CardPrefab.StartCount;
        _obstacleType = CardPrefab.ObstacleType;
        _buttonImage = CardPrefab.ButtonImage;


        _buttonEffect = GetComponent<ButtonEffect>();
        _currentCount = _startCount;
        ObstacleImage.sprite = _buttonImage;
        CountText.text = _startCount.ToString();
        _textStartSize = CountText.gameObject.transform.localScale;

        _buttonEffect._doClick = CreateObstacle;


        _sides = GameObject.FindGameObjectsWithTag("grid").ToList();
    
    }

    public void CreateObstacle()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       

        if (_currentCount - 1 >= 0)
        {


            GameObject _spawnedObstacle = Instantiate(_obstacleType);

            for (int i = 0; i < _sides.Count; i++)
            {
                int randNumber = Random.Range(0, _sides.Count);
                if (_sides[randNumber].GetComponent<Side>().Stock == null)
                {
                    _sides[randNumber].GetComponent<Side>().Stock = _spawnedObstacle;
                    _spawnedObstacle.transform.position = _sides[randNumber].transform.position;
                    break;
                }
            }
            
            
            
            _currentCount--;
            CountText.text = _currentCount.ToString();

            CountText.transform.DOScale(new Vector3(_textStartSize.x * -1, _textStartSize.y, _textStartSize.z) , .15f).OnComplete(() => CountText.transform.DOScale(_textStartSize, .15f));
        }
        else
        {
            CountText.DOColor(ClickColorForText, .1f).OnComplete(() => CountText.DOColor(new Color(255, 255, 255, 1), .1f)).OnComplete(() => _canClick = true);
            _canClick = false;
        }

       
    }


}
