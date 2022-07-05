using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ManagerKata : MonoBehaviour
{
	public static ManagerKata Instance {get; private set;}
	[SerializeField] Drag hurufPrefab;
	[SerializeField] Transform slotAwal, slotAkhir;
	[SerializeField] string[] listKataKata;

	private int poinKata, poin;
	string[] kataPertama = {"SEPATU", "RODA", "BAJU", "DAUN", "PINTU", "CICAK", "PISANG", "BAYAM", "TANGAN", "ZEBRA", "BELAJAR", "TELINGA", "BUNGA"};
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        // InitKata(listKataKata[0]);
        InitKata(kataPertama[Random.Range(0, kataPertama.Length)]);
    }

    void InitKata(string kata){
    	char[] hurufKata = kata.ToCharArray();
    	char[] hurufAcak = new char[hurufKata.Length];

    	List<char> hurufKataCopy = new List<char>();
    	hurufKataCopy = hurufKata.ToList();

    	for(int i = 0; i < hurufAcak.Length; i++){
    		int randomIndex = Random.Range(0, hurufKataCopy.Count);
    		hurufAcak[i] = hurufKataCopy[randomIndex];
    		hurufKataCopy.RemoveAt(randomIndex);

    		Drag temp = Instantiate(hurufPrefab, slotAwal);

    		temp.Inisialisasi(slotAwal, hurufAcak[i].ToString(), false);
    	}

    	for(int i = 0; i < hurufKata.Length; i++){
    		Drag temp = Instantiate(hurufPrefab, slotAkhir);
    		temp.Inisialisasi(slotAkhir, hurufKata[i].ToString(), true);

    	}

    	poinKata = hurufKata.Length;
    }

    public void TambahPoin(){
    	poin++;
    	if(poin == poinKata){
    		Debug.Log("Berhasil");
    	}
    }
}
