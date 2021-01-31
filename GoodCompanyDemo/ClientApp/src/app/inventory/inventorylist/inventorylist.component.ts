import { Component, OnInit } from '@angular/core';
import { ComputerService } from '../../services/computer.service';
import { Computer } from '../../models/computer';

@Component({
  selector: 'app-inventorylist',
  templateUrl: './inventorylist.component.html',
  styleUrls: ['./inventorylist.component.css'],
})
export class InventoryListComponent implements OnInit {
  public computers: Computer[];

  constructor(private computerService: ComputerService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.computerService.getComputers<Computer[]>().subscribe((result) => {
      this.computers = result;
      console.log('Computers length:' + this.computers.length);
      console.log(this.computers[0]);
    });
  }
}
