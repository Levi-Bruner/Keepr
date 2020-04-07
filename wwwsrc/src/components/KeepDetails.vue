<template>
  <div class="row justify-content-center">
    <div class="col-10 col-md-6">
      <div class="card bg-dark text-white">
        <img class="card-img" :src="activeKeep.Img" alt />
        <div class="card-body">
          <h4 class="card-title">{{activeKeep.Title}}</h4>
          <p class="card-text text-center">{{activeKeep.Description}}</p>
          <p
            class="text-center"
          >Views: {{activeKeep.Views}} - Keeps: {{activeKeep.Keeps}} - Shares: {{activeKeep.Shares}}</p>
          <button @click="deleteKeep" title="Delete this Keep" class="btn btn-danger">X</button>
          <div>
            <form @submit.prevent="editKeep">
              <input type="text" placeholder="name" v-model="activeKeep.Name" />
              <input type="text" placeholder="description" v-model="activeKeep.Description" />
              <button class="btn btn-secondary" title="Edit this Keep">E</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "KeepDetails",
  data() {
    return {
      newEdit: {}
    };
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    editKeep() {
      let activeKeep = {
        Id: this.activeKeep.Id
      };
      this.$store.dispatch("editKeep", this.activeKeep);
    },
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.activeKeep.Id);
    }
  }
};
</script>

<style scoped>
</style>