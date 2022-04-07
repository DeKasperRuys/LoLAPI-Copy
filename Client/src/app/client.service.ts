import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Http, Response } from '@angular/http';
import { Observable, of, throwError, pipe } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { JsonPipe } from '@angular/common';






@Injectable({
  providedIn: 'root'
})
export class ClientService {
public apiUrl = 'https://localhost:44392/api/v1/';

  constructor( private httpclnt: HttpClient) {}

  //CHAMPS
  getChampions() {
    return this.httpclnt.get<Champion[]>(this.apiUrl + 'champions');


  }

  getChampionsById(id: number) {
    if(id == null) id = 2;
    return this.httpclnt.get<Champion>(this.apiUrl + 'champions/' + id );
  }

  getChampionsByFactionId(factionId: number) {
    return this.httpclnt.get<Champion[]>(this.apiUrl + 'champions/faction?idin=' + factionId);
  }

  
  getChampionsPaging(page: number, itemsperpage: number, dir: string ) {
    return this.httpclnt.get<Champion[]>(this.apiUrl + 'champions?page=' + page + '&length=' + itemsperpage + '&sort=title' + '&dir=' + dir);
  }

  getChampionsSorting(sort: string, dir: string) {
    return this.httpclnt.get<Champion[]>(this.apiUrl + 'champions?sort=' + sort + '&dir=' + dir);
  }

  GetChampionByRole(name: string) {
      return this.httpclnt.get<Champion[]>(this.apiUrl + 'champions?name=' + name);
  }


  postChampion = function(cname: string = '', crole: string = '', releastedate: Date, factionId: number) {
    const errorLabel = document.getElementById("AddChampionError");
    return this.httpclnt.post(this.apiUrl  + 'champions', {
      championName:  cname,
      championRole: crole,
      releaseDate: releastedate,
      factionId: factionId
      //werkt niet met ingevulde id om 1 of andere reden fix
    } ).subscribe(data => console.log("success", data), error => errorLabel.textContent = error.error.errors.ChampionName[0]);

  };

  updateChampion(cname: string = '', crole: string = '', releastedate: Date , cid: number, factionid: number) {

    return this.httpclnt.put(this.apiUrl + 'champions', {
      championName: cname,
      championRole: crole,
      releaseDate: releastedate,
      id: cid,
      factionId: factionid
      //factionId: factionid
    } ).subscribe();

  }

  deleteChampion(Cid: number) {


    const deleteUrl = this.apiUrl  + 'champions' + '/' + Cid;
    console.log(deleteUrl);
    return this.httpclnt.delete(deleteUrl).subscribe();
  }
  
  getAllFactions() {
    return this.httpclnt.get<Faction[]>(this.apiUrl + 'factions');

  }

  postFaction(Fname: string, Fdescription : string) {
    return this.httpclnt.post(this.apiUrl  + 'factions', {
      factionName: Fname,
      factionDesciption: Fdescription
    } ).subscribe();
  }
}

export interface Champion {
  id: number;
  championName: string;
  championRole: string;
  releaseDate: Date;
  factionId: number;
  //championItem?: any;
}
export interface Faction {
  id: number;
  factionName: string;
  factionDesciption: string;
}
export interface Item {
  itemid: number;
  itemName: string;
  //championItem?: any;
}
export interface Background {
  backgroundid: number;
  name: string;
  backgroundOfChamp: string;
}
export interface Role {
  roleid: number;
  roleName: string;
}









export interface RootObject {
image_results: Imageresult[];
}
export interface Imageresult {
  thumbnail: string;
}

