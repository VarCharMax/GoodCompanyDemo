import { Component, Input, OnInit } from '@angular/core';
import { Computer } from 'src/app/models/computer';

@Component({
  selector: 'app-inventorydetail',
  templateUrl: './inventorydetail.component.html',
  styleUrls: ['./inventorydetail.component.css'],
})
export class InventoryDetailComponent implements OnInit {
  @Input() computer: Computer;
  @Input() id: string;

  constructor() {}

  ngOnInit(): void {}
}
