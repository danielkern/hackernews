import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class StringHelper implements IStringHelper {
  constructor() {

  }

  capitalizeFirstLetter(str: string) {
    if (this.isEmpty(str)) {
      return str;
    }

    return str.charAt(0).toUpperCase() + str.slice(1);
  }

  isEmpty(str: string) {
    return (!str || str.length === 0);
  }
}

export interface IStringHelper {
  capitalizeFirstLetter(str: string): string;
  isEmpty(str: string): boolean;
}
