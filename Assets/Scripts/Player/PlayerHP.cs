using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
   [Range(1, 9999)][SerializeField] private int _maxHealth;
   [SerializeField] private string _startingGameScene;
   [SerializeField]private int _health;
   private Slider _playerHPBar;
   private Slider _playerXPBar;
   private TMP_Text _playerLevelText;
   private BoxCollider2D _playerBoxCollider2D;
   [SerializeField]private float _damageRangeTimer = 1f;
   private float _currentDamageTime;
   public event EventHandler onTakeDamage;
   private float _xp = 0;
   [SerializeField] private float[] _levelsXP;
   private int _level = 1;
   [SerializeField] private float _coficent = 1.18f;


  

   private void Start()
   {
      StartCoroutine(LoadLevelsXP());
      
      _health = _maxHealth;
      _playerHPBar = GameObject.FindGameObjectWithTag("HPBar").GetComponent<Slider>();
      _playerXPBar = GameObject.FindGameObjectWithTag("XPBar").GetComponent<Slider>();
      _playerLevelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<TMP_Text>();
      _playerBoxCollider2D = GetComponent<BoxCollider2D>();
      _playerHPBar.maxValue = _maxHealth;
      _playerHPBar.value = _health;
      
      StartCoroutine(Leveling());
   }

   private void FixedUpdate()
   {
      _playerXPBar.value = _xp;
   }

   public void TakeDamage(int damage, PolygonCollider2D _enemyAttackPolygonCollider2D)
   {
      if (_playerBoxCollider2D.IsTouching(_enemyAttackPolygonCollider2D) && Time.time > _currentDamageTime)
      {
         _health -= damage;
         _currentDamageTime = Time.time + _damageRangeTimer;
         onTakeDamage?.Invoke(this, EventArgs.Empty);
         _playerHPBar.value = _health;
         CheckDie();
      }
   }

   public int Level() => _level;

   public void GetXP(float xp)
   {
      _xp += xp;
   }

   private void CheckDie()
   {
      if (_health <= 0)
      {
         SceneManager.LoadScene(_startingGameScene);
      }
   }

   private IEnumerator Leveling()
   {
      while (true)
      {
         if (_levelsXP[_level] <= _xp)
         {
            _xp -= _levelsXP[_level];
            _level++;
         }

         _playerXPBar.maxValue = _levelsXP[_level];
         _playerLevelText.text = _level.ToString();
         yield return new WaitForSeconds(2);
      }
   }
   private IEnumerator LoadLevelsXP()
   {
      for (int i = 0; i < _levelsXP.Length; i++)
      {
         if (i == 0)
               _levelsXP[i] = 2;
         else
         {
            _levelsXP[i] = _levelsXP[i - 1] + ((_levelsXP[i - 1] / 100) * _coficent);
         }
      }
      yield return new WaitForSeconds(1);
   }
}
