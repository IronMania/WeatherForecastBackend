<template>
  <div id="Search" class="container">
    <div class="alert alert-danger row" role="alert" v-if="showError">{{errorMessage}}</div>
    <div class="row">
      <suggestions
      v-model="city"
      :options="searchResults"
      :onInputChange="searchHistory"
      :onItemSelected="searchWeather"
      class="col col-8"
      >
      </suggestions>
      <button v-on:click="searchWeather(city)" class="col col-4" >Search</button>
    </div>
    <b-tabs>
    <b-tab 
      v-for="(item) in request.forecastsPerDay"
      v-bind:key="item.id" 
      v-bind:title="item | convertDay"
      >
           <forecast-day :item="item"></forecast-day>
    </b-tab>
    </b-tabs>

  </div>
</template>

<script>
import axios from 'axios'
import ForecastDay from './ForecastDay.vue'
import moment from 'moment'
import Suggestions from 'v-suggestions'
import 'v-suggestions/dist/v-suggestions.css'

export default {
  name: 'Search',
    components: {
    ForecastDay,
    Suggestions 
  },
  data(){
    return{
      city : '',
      request: '',
      errorMessage: '',
      searchResults: {
        placeholder: 'city or postal code in Germany',
        inputClass: 'col col-12'
      },
      showError: false
    }
  },
  methods: {
    searchHistory(city) {
      if (city.trim().length === 0) {
        return null
      }
      return new Promise(resolve => {
        axios
          .get( process.env.VUE_APP_BACKEND_URL + 'weather/history', { params: {city: city}})
          .then(response => {
            const items = []
            response.data.searchResults.forEach((item) => {
                items.push(item)
            })
            resolve(items)
        })
      })
      },
    searchWeather(city){
      this.city = city;
      this.showError = false;
      axios
        .get(process.env.VUE_APP_BACKEND_URL + 'weather/forecast', { params: {city: city}})
        .then(response => {
            this.request = response.data
          },(error) =>{
            this.showError = true;
            this.errorMessage = error.response.data;
        }
          
        )
      }

    },
    filters: {
  convertDay: function (value) {
    if (!value) return ''
    return moment(value.day).format("DD.MM.YYYY");
  }
}
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
