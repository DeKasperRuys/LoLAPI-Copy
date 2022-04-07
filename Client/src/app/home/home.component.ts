import { Component, OnInit, Query } from '@angular/core';
import { ClientService, Champion, Faction, Role, Item, Background, Imageresult, RootObject} from '../client.service';
import { FormsModule, ReactiveFormsModule, Validator, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { fn } from '@angular/compiler/src/output/output_ast';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //public apiUrl = 'https://localhost:44392/api/v1/champions';
  Champions$: Champion[];
  Faction$: Faction[];
  //ChampionSelected$: Champion[];
  ChampionSelectedByName$: Champion[];
  ChampionSelectedByFactionId$: Champion[];
  ChampionSearch$: string;
  ItemsPerPage$: number [] = [10, 20, 30];
  itemsperpage: number;
  ChampionSelectedById$: Champion;
  selectedFaction;
  data: Array<any>;
  //totalRecords: number;
  page = 0;
  sorting = 0;
  choise: string;
  sort: string;
  public selectedChampion = 0;
  id: number;
  ualbid: number;
  error: any;





  constructor( private cliService: ClientService, private http: HttpClient ) { }




  ngOnInit() {
    this.cliService.getAllFactions()
        .subscribe(data => this.Faction$ = data);

  }




  GetAllChampions() {
        return this.cliService.getChampions()
        .subscribe(data => this.Champions$ = data);

  }

  GetChampionById(champid: number) {
    console.log(champid);
    return this.cliService.getChampionsById(champid).subscribe(data => this.ChampionSelectedById$ = data);
  }

  //////////////
  GeChampionByRole() {
    console.log(this.ChampionSearch$);
    return this.cliService.GetChampionByRole(this.ChampionSearch$)
    .subscribe(data => this.ChampionSelectedByName$ = data);

  }
  ///////////////////
  GetChampionByFactionId() {
    console.log(this.selectedFaction);
    return this.cliService.getChampionsByFactionId(this.selectedFaction).subscribe(data => this.ChampionSelectedByFactionId$ = data);

  }

  GetChampionsPaging(value: number) {

      console.log(this.page);
      console.log(this.itemsperpage);
      switch (value) {
        case 0:
          this.page = 0;
          return this.cliService.getChampionsPaging(this.page, this.itemsperpage, this.choise)
          .subscribe(data => this.Champions$ = data);
          break;
        case 1:
          this.page++;
          this.selectedChampion += this.itemsperpage;
          return this.cliService.getChampionsPaging(this.page, this.itemsperpage, this.choise)
          .subscribe(data => this.Champions$ = data);
          break;
        case 2:
          this.page--;
          this.selectedChampion -= this.itemsperpage;

          return this.cliService.getChampionsPaging(this.page, this.itemsperpage, this.choise)
          .subscribe(data => this.Champions$ = data);
          break;
        case 3:
            this.sorting++;
            if (this.sorting % 2 === 0) {
              this.choise = 'asc';

            } else {
              this.choise = 'desc';
            }
            return this.cliService.getChampionsPaging(this.page, this.itemsperpage, this.choise)
            .subscribe(data => this.Champions$ = data);
            break;
      }

  }


  PostChampion(name: string, role: string, releaseDate: Date, factionid:number) {

    const rdate = new Date(releaseDate);
    factionid = +factionid;
    return this.cliService.postChampion( name, role, releaseDate, factionid);
    }


  DeleteChampion(Bdelete: number) {
    return this.cliService.deleteChampion(Bdelete);
  }

  UpdateChampion(cName: string, cRole: string , releaseDate: Date, cid: number, factionid: number) {
    //BalbumId = +BalbumId;
    //bartistId = +bartistId;
    cid = +cid;
    factionid = +factionid;
    const udate = new Date(releaseDate);
    console.log(this.ualbid);
    // name role release id
    return this.cliService.updateChampion(cName, cRole, releaseDate, cid, factionid);
  }

  GetAllArtists() {
    return this.cliService.getAllFactions()
    .subscribe(data => this.Faction$ = data);
}

GetSelectedFaction() {
  console.log(this.selectedFaction);
  return this.cliService.getAllFactions().subscribe(data => this.Faction$ = data);


}

PostFaction(Fname: string, Fdescription: string) {
  console.log(Fname);
  return this.cliService.postFaction(Fname, Fdescription);
}



  isNextValid() {
    if (this.selectedChampion > this.Champions$.length) {
      return true;
    } else {
        return false;
    }
  }

  isPreviousValid() {
    if (this.selectedChampion <= 0) {
        return true;
    } else if (this.selectedChampion >= 10) {
        return false;
    }
  }

}
