import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TheClass, Subclass, TheRace, TheSpell } from './OnlineAPI'
import { first } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OnlineAPIService {

  constructor(private client: HttpClient) { }

  getClasses(value: string){
    return this.client.get<TheClass>("http://www.dnd5eapi.co/api/classes/"+value);
  // return this.authService.login('d', 'a').pipe(first()).subscribe(data => {
   //  console.log(data);
  // })

  }

  getSubClasses(value: string){
    return this.client.get<Subclass>("http://www.dnd5eapi.co/api/classes/" + value + "/subclasses");
  }

  getRaces(value: string){
    return this.client.get<TheRace>("http://www.dnd5eapi.co/api/races/" + value);
  }
  
  getSpell(value: string){
    return this.client.get<TheSpell>("http://www.dnd5eapi.co/api/spells/" + value);
  }
  geturl(){
    return this.client.get<TheClass>("http://www.dnd5eapi.co/api/classes/");
  }
}
