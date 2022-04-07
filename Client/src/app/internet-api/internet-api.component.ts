import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OnlineAPIService } from './online-api.service';
import { TheClass, Subclass, TheRace, TheSpell } from './OnlineAPI';


@Component({
  selector: 'app-internet-api',
  templateUrl: './internet-api.component.html',
  styleUrls: ['./internet-api.component.css']
})
export class InternetAPIComponent implements OnInit {
  
  constructor(private OnlineAPIService: OnlineAPIService) { }
  //Classes: Classes;
  //ClassesInfo: ClassesInfo
  TheClass : TheClass
  Subclass : Subclass
  test : string
  TheRace : TheRace
  TheSpell : TheSpell

  setFieldsClass(value: string){
   this.OnlineAPIService.getClasses(value).subscribe(data=>{
      this.TheClass = data;
      this.TheClass.subclasses = data.subclasses;
      this.test = this.TheClass.subclasses.toString();
    });
    //this.OnlineAPIService.getClasses(value);
  }
  setFieldsSubClass(value: string){
    this.OnlineAPIService.getRaces(value).subscribe(data=>{
    this.Subclass = data
    });
  }

  setFieldsRace(value: string){
    this.OnlineAPIService.getRaces(value).subscribe(data=>{
    this.TheRace = data
    });
  }

  setFieldsSpell(value: string){
    this.OnlineAPIService.getSpell(value).subscribe(data=>{
    this.TheSpell = data
    });
  }
  ngOnInit() {
  }

}
