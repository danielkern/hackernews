import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get('/');
  }

  navigateToUrl(url: string) {
    return browser.get(url);
  }

  clickLoadMore() {
    return element(by.css('btn-load-more')).click();
  }

  getLoadMoreButton() {
    return element(by.css('btn-load-more'));
  }

  getPageSizeValue() {
    return element(by.css('page-size option[selected]')).getAttribute('value');
  }

  getMainHeading() {
    return element(by.css('app-root h1')).getText();
  }
}
