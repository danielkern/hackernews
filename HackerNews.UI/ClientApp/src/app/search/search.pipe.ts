import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchfilter',
  pure: false
})
export class SearchFilterPipe implements PipeTransform {
  transform(items: any[], filter: any): any {
    if (!items) {
      return [];
    }
    if (!filter) {
      return items;
    }
    filter = filter.toLocaleLowerCase();

    return items.filter(item => {
      return item.title.toLocaleLowerCase().includes(filter);
    });
  }
}
