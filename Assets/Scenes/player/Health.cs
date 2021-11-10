using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // �̗͒l���i�[����ϐ��i�萔�l 100�j
    public const int maxHealth = 100;
    // ���݂̗̑͒l���i�[����ϐ��i�����l�� maxHealth�j
    public int currentHealth = maxHealth;

    // �_���[�W����
    public void TakeDamage(int amount)
    {
        // ���݂̗̑͒l���� ���� amount �̒l������
        currentHealth -= amount;
        // ���݂̗̑͒l�� 0 �ȉ��̏ꍇ
        if (currentHealth <= 0)
        {
            // ���݂̗̑͒l�� 0 ����
            currentHealth = 0;
            // �R���\�[����"Dead!"��\������
            Debug.Log("Dead!");
        }
    }
}