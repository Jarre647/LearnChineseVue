import 'bootstrap/dist/css/bootstrap.css';
import { createApp} from 'vue';
import App from './App.vue';
import { stateSymbol, createState } from './store';
import router from './router/index.js'

const app = createApp(App);
app.provide(stateSymbol, createState());
app.use(router).mount('#app');


