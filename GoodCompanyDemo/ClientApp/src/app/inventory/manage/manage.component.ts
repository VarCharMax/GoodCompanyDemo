import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Computer } from '../../models/computer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BaseFormComponent } from './base.form.component';
import { ComputerService } from '../../services/computer.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css'],
})
export class ManageComponent extends BaseFormComponent implements OnInit {
  form: FormGroup;
  typeName: string;
  brand: string;
  processorName: string;
  quantity: number;
  ramSlots: number;
  usbPorts: number;
  imageUrl: string;
  screenSize: number;
  newComputer: Computer;

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private computerService: ComputerService
  ) {
    super();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      typeName: [''],
      processorName: ['', Validators.required],
      brand: ['', [Validators.required]],
      quantity: ['', [Validators.required]],
      ramSlots: [''],
      usbPorts: [''],
      screenSize: [''],
      imageUrl: [''],
    });

    this.form.get('typeName').setValue('Desktop', { onlySelf: true });
  }

  changeType(e) {
    this.form.get('typeName').setValue(e.target.value, {
      onlySelf: true,
    });
  }

  onSubmit() {
    this.newComputer = new Computer(
      this.form.get('typeName').value,
      this.form.get('brand').value,
      this.form.get('processorName').value,
      this.form.get('quantity').value,
      this.form.get('usbPorts').value,
      this.form.get('ramSlots').value,
      this.form.get('imageUrl').value,
      this.form.get('screenSize').value
    );
    console.log('brand ' + this.newComputer.brand);
    this.computerService
      .post<Computer>(this.newComputer)
      .subscribe((result) => {
        this.router.navigate(['/']);
      });
  }
}
