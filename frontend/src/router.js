import { createRouter, createWebHistory } from 'vue-router'
import SettingsPage from './views/SettingsPage.vue'
import HomePage from './views/HomePage.vue'
import HelpPage from './views/HelpPage.vue'
import LoginPage from './views/LoginPage.vue'
import NewTaskPage from './views/NewTaskPage.vue'
import SearchPage from './views/SearchPage.vue'
import EditTaskPage from './views/EditTaskPage.vue'
import NotesPage from './views/NotesPage.vue'
import NewNotePage from './views/NewNotePage.vue'
import RegisterPage from './views/RegisterPage.vue'
import ResetPage from './views/ResetPage.vue'
import EditNotePage from './views/EditNotePage.vue'

const routes = [
  { path: '/tasks', component: HomePage },
  { path: '/settings', component: SettingsPage },
  { path: '/help', component: HelpPage },
  { path: '/', component: LoginPage },
  { path: '/new-task', component: NewTaskPage },
  { path: '/search', component: SearchPage },
  { path: '/edit-task', component: EditTaskPage },
  { path: '/notes', component: NotesPage },
  { path: '/new-note', component: NewNotePage },
  { path: '/register', component: RegisterPage },
  { path: '/reset', component: ResetPage },
  { path: '/edit-note', component: EditNotePage },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
